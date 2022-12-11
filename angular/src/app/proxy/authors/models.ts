import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface AuthorCreateDto {
  name: string;
  birthDate: string;
  shortBio?: string;
}

export interface AuthorDto extends EntityDto<string> {
  name?: string;
  birthDate?: string;
  shortBio?: string;
}

export interface AuthorGetListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface AuthorUpdateDto {
  name: string;
  birthDate: string;
  shortBio?: string;
}
