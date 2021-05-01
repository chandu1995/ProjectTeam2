import { Component, OnInit } from '@angular/core';
import { PmsService } from '../pms.service';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  imageUrl: string = "/assets/img/default-image.png";
  fileToUpload: File = null;

  constructor(private productService : PmsService) {

  }

  ngOnInit(): void {
  }

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    //Show image preview
    var reader = new FileReader();
    reader.onload = (event:any) => {
      this.imageUrl = event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }

   OnSubmit(PName:any,ImageName:any,Image:any,Price:any,Discount:any,Quantity:any,IsStock:any){
    this.productService.postFile(PName.value,ImageName.value,this.fileToUpload,Price.value,Discount.value,Quantity.value,IsStock.value).subscribe(
      data =>{
        console.log('done');
        PName.value = null;
        Image.value = null;
        this.imageUrl = "/assets/img/default-image.png";
      }
    );
   }
}
