import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../../environments/environment";
import {AddProductPetition, Product} from "../../../core/entities/Product";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url : string = environment.APIproducts + '/Product'
  constructor(private http :  HttpClient) { }

  getProductById(id : string) : Observable<Product>{
    return this.http.get<Product>(`${this.url}/${id}`)
  }

  getProducts(pageSize? :number ,  pageNumber? :number) : Observable<Product[]>{

    if(pageSize != null && pageNumber != null){
      return this.http.get<Product[]>(`${this.url}?pageSize=${pageSize}&pageNumber=${pageNumber}`);
    }

    if(pageSize == null && pageNumber == null){
      return this.http.get<Product[]>(`${this.url}?pageSize=1000&pageNumber=1`)
    }

    return this.http.get<Product[]>(this.url)
  }

  saveProduct(body : AddProductPetition ): Observable<any>{
    return this.http.post(this.url, body);
  }

  updateProduct(body : Product) : Observable<any>{
    return this.http.put(this.url, body);
  }

  deleteProductById(id : string) : Observable<any>{
    return this.http.delete(`${this.url}/${id}`)
  }
}
