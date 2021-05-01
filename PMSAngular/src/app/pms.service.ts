import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PmsService {

  constructor(private http : HttpClient) { }

  postFile(PName: string, ImageName: string, fileToUpload: File,Discount: string, Price: string,IsStock: string, Quantity: string) {
    const endpoint = 'https://localhost:44335/api/AddProduct';

    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload, fileToUpload.name);
    formData.append('PName', PName);
    formData.append('ImageName', ImageName);
    formData.append('Discount', Discount);
    formData.append('Price', Price);
    formData.append('Quantity', Quantity);
    formData.append('IsStock', IsStock);
    console.log('service code')
    return this.http.post(endpoint, formData);
  }
}
