import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { TagService, TagDto } from '@proxy/tags';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class TagComponent implements OnInit {
  tag = { items: [], totalCount: 0 } as PagedResultDto<TagDto>;

  isModalOpen = false;

  form: FormGroup;

  selectedTag = {} as TagDto;

  constructor(
    public readonly list: ListService,
    private tagService: TagService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) { }

  ngOnInit(): void {
    const tagStreamCreator = (query) => this.tagService.getList(query);

    this.list.hookToQuery(tagStreamCreator).subscribe((response) => {
      this.tag = response;
    });
  }

  createTag() {
    this.selectedTag = {} as TagDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editTag(id: string) {
    this.tagService.get(id).subscribe((tag) => {
      this.selectedTag = tag;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedTag.name || '', Validators.required],
      desc: [this.selectedTag.desc || '', Validators.required,],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedTag.id) {
      this.tagService
        .update(this.selectedTag.id, this.form.value)
        .subscribe(() => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        });
    } else {
      this.tagService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
      .subscribe((status) => {
        if (status === Confirmation.Status.confirm) {
          this.tagService.delete(id).subscribe(() => this.list.get());
        }
      });
  }
}
