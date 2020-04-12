import { NgModule } from '@angular/core';
import { ShopComponent } from './shop.component';
import { FormsModule } from '@angular/forms';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [ShopComponent, ProductItemComponent],
  imports: [
    SharedModule,
    FormsModule
  ],
  exports: [ShopComponent]
})
export class ShopModule { }
