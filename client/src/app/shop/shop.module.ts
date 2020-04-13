import { NgModule } from '@angular/core';
import { ShopComponent } from './shop.component';
import { FormsModule } from '@angular/forms';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RouterModule } from '@angular/router';
import { ShopRoutingModule } from './shop-routing.module';

@NgModule({
  declarations: [ShopComponent, ProductItemComponent, ProductDetailsComponent],
  imports: [
    SharedModule,
    FormsModule,
    ShopRoutingModule,
    RouterModule
  ],

})
export class ShopModule { }
