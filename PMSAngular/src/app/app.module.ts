import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import { PaymentdetailsComponent } from './paymentdetails/paymentdetails.component';
import { TrackByOrderDetailsComponent } from './track-by-order-details/track-by-order-details.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    PaymentdetailsComponent,
    TrackByOrderDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
