import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { PaginationHeaderComponent } from './components/pagination-header/pagination-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { CarouselModule } from 'ngx-bootstrap';
@NgModule({
  declarations: [PaginationHeaderComponent, PagerComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    NzMenuModule,
    NzDividerModule,
    NzSelectModule,
    CarouselModule.forRoot()
  ],
  exports: [

    CommonModule,
    PaginationModule,
    NzMenuModule,
    NzDividerModule,
    NzSelectModule,
    PaginationHeaderComponent,
    PagerComponent,
    CarouselModule
  ]
})
export class SharedModule { }
