import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-pagination-header',
  templateUrl: './pagination-header.component.html',
  styleUrls: ['./pagination-header.component.scss']
})
export class PaginationHeaderComponent implements OnInit {
  @Input("pageNumber") pageNumber: number;
  @Input("pageSize") pageSize: number;
  @Input("totalCount") totalCount: Number;

  constructor() { }

  ngOnInit(): void {
  }

}
