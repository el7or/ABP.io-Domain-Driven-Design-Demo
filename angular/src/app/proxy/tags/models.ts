import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface TagCreateDto {
  name: string;
  desc?: string;
}

export interface TagDto extends EntityDto<string> {
  name?: string;
  desc?: string;
}

export interface TagGetListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface TagUpdateDto {
  name: string;
  desc?: string;
}
