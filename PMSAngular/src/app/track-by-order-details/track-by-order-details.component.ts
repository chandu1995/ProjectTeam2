import { Component, OnInit } from '@angular/core';
import { PmsService } from '../pms.service';
@Component({
  selector: 'app-track-by-order-details',
  templateUrl: './track-by-order-details.component.html',
  styleUrls: ['./track-by-order-details.component.css']
})
export class TrackByOrderDetailsComponent implements OnInit {
  OrderId:any;
                    ProductId :any;
                    ProductQuantity :any;
                    UserId :any;
                    BookingOn:any;
                    DeliveredOn :any;
                    p:any=new TrackOrderdetails();

  constructor(private orderservice  : PmsService) { }

  ngOnInit(): void {
    this.gettrackorder();
  }
  gettrackorder(){
    this.orderservice.gettrackorder().subscribe(response => {

      this.p = response;
      this.OrderId=this.p.OrderId;
      this.ProductId=this.p.ProductId;
      this.ProductQuantity=this.p.ProductQuantity;
      this.UserId=this.p.UserId;
      this.BookingOn=this.p.BookingOn;
      this.DeliveredOn=this.p.DeliveredOn;



    },
    error=>{
      alert('An unexpected error occured');
      console.log(error);
    });


}
}

class TrackOrderdetails{

  OrderId:any;
                    ProductId :any;
                    ProductQuantity :any;
                    UserId :any;
                    BookingOn :any;
                    DeliveredOn :any;

}
