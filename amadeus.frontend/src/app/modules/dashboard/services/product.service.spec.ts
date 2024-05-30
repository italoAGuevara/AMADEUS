import { TestBed } from '@angular/core/testing';

import { ProductService } from './product.service';
import {environment} from "../../../../environments/environment";
import {AddProductPetition, Product} from "../../../core/entities/Product";
import {HttpClientTestingModule, HttpTestingController} from "@angular/common/http/testing";

describe('ProductService', () => {
  let service: ProductService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ProductService]
    });

    service = TestBed.inject(ProductService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should retrieve a product by ID', () => {
    const mockProduct: Product = { id: '1', name: 'Product1', barCode: '12345', description: 'Product Description', price : 10, stockQuantity : 10, tmStmp : '2024-05-30T05:07:56.163759' };

    service.getProductById('1').subscribe(product => {
      expect(product).toEqual(mockProduct);
    });

    const req = httpMock.expectOne(`${environment.APIproducts}/Product/1`);
    expect(req.request.method).toBe('GET');
    req.flush(mockProduct);
  });

  it('should retrieve products with pagination', () => {
    const mockProducts: Product[] = [
      { id: '1', name: 'Product1', barCode: '12345', description: 'Product Description', price : 10, stockQuantity : 10, tmStmp : '2024-05-30T05:07:56.163759' },
      { id: '2', name: 'Product2', barCode: '67890', description: 'Product Description', price : 10, stockQuantity : 10, tmStmp : '2024-05-30T05:07:56.163759' }
    ];

    service.getProducts(10, 1).subscribe(products => {
      expect(products.length).toBe(2);
      expect(products).toEqual(mockProducts);
    });

    const req = httpMock.expectOne(`${environment.APIproducts}/Product?pageSize=10&pageNumber=1`);
    expect(req.request.method).toBe('GET');
    req.flush(mockProducts);
  });

  it('should retrieve products with default pagination', () => {
    const mockProducts: Product[] = [
      { id: '1', name: 'Product1', barCode: '12345', description: 'Product Description', price : 10, stockQuantity : 10, tmStmp : '2024-05-30T05:07:56.163759' },
      { id: '2', name: 'Product2', barCode: '67890', description: 'Product Description', price : 10, stockQuantity : 10, tmStmp : '2024-05-30T05:07:56.163759' }
    ];

    service.getProducts().subscribe(products => {
      expect(products.length).toBe(2);
      expect(products).toEqual(mockProducts);
    });

    const req = httpMock.expectOne(`${environment.APIproducts}/Product?pageSize=1000&pageNumber=1`);
    expect(req.request.method).toBe('GET');
    req.flush(mockProducts);
  });

  it('should save a new product', () => {
    const newProduct: AddProductPetition = { name: 'New Product', barCode: '54321', description: 'New Description', price : 10, stockQuantity : 10 };

    service.saveProduct(newProduct).subscribe(response => {
      expect(response).toEqual(newProduct);
    });

    const req = httpMock.expectOne(`${environment.APIproducts}/Product`);
    expect(req.request.method).toBe('POST');
    req.flush(newProduct);
  });

  it('should update an existing product', () => {
    const updatedProduct: Product = { id: '1', name: 'Updated Product', barCode: '54321', description: 'Updated Description', price : 10, stockQuantity : 10, tmStmp : '2024-05-30T05:07:56.163759' };

    service.updateProduct(updatedProduct).subscribe(response => {
      expect(response).toEqual(updatedProduct);
    });

    const req = httpMock.expectOne(`${environment.APIproducts}/Product`);
    expect(req.request.method).toBe('PUT');
    req.flush(updatedProduct);
  });

  it('should delete a product by ID', () => {
    service.deleteProductById('1').subscribe(response => {
      expect(response).toEqual({});
    });

    const req = httpMock.expectOne(`${environment.APIproducts}/Product/1`);
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });
});
