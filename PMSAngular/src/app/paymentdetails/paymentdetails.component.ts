import { Component, OnInit } from '@angular/core';

import { PmsService } from '../pms.service';

@Component({
  selector: 'app-paymentdetails',
  templateUrl: './paymentdetails.component.html',
  styleUrls: ['./paymentdetails.component.css']
})
export class PaymentdetailsComponent implements OnInit {
                    PayId:any;
                    OrderId :any;
                    UserId :any;
                    BankName :any;
                    CardNo :any;
                    NameOnCard :any;
                    ExpiryDate:any;
                    p:any = new Payment();

  constructor(private PaymentService : PmsService) { }

  ngOnInit(): void {
    this.getPaymentById();
  }

  getPaymentById(){
    this.PaymentService.getPaymentdetails(this.UserId).subscribe(response => {

      this.p = response;
      this.PayId=this.p.PayId;
      this.OrderId=this.p.OrderId;
      this.UserId=this.p.UserId;
      this.BankName=this.p.BankName;
      this.CardNo=this.p.CardNo;
      this.NameOnCard=this.p.NameOnCard;
      this.ExpiryDate=this.p.ExpiryDate;

    },
    error=>{
      alert('An unexpected error occured');
      console.log(error);
    });

}

}
class Payment{

                    PayId:any;
                    OrderId :any;
                    UserId :any;
                    BankName :any;
                    CardNo :any;
                    NameOnCard :any;
                    ExpiryDate:any;
}
