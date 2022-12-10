import type { TagCreateDto, TagDto, TagGetListDto, TagUpdateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TagService {
  apiName = 'Default';
  

  create = (input: TagCreateDto) =>
    this.restService.request<any, TagDto>({
      method: 'POST',
      url: '/api/app/tag',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/tag/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, TagDto>({
      method: 'GET',
      url: `/api/app/tag/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: TagGetListDto) =>
    this.restService.request<any, PagedResultDto<TagDto>>({
      method: 'GET',
      url: '/api/app/tag',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: TagUpdateDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/tag/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
