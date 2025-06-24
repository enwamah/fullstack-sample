import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product, CreateProductDto } from '../models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Product {

  private url = '/api/products';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.url);
  }

  createProduct(product: CreateProductDto): Observable<Product> {
    return this.http.post<Product>(this.url, product);
  }
}
