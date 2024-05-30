import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductTableComponent } from './product-table.component';
import {ProductService} from "../services/product.service";
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {of, throwError} from "rxjs";
import {MessageService} from "primeng/api";

describe('ProductTableComponent', () => {
  let component: ProductTableComponent;
  let fixture: ComponentFixture<ProductTableComponent>;
  let productServiceSpy: jasmine.SpyObj<ProductService>;
  let messageServiceSpy: jasmine.SpyObj<MessageService>;

  beforeEach(async () => {
    const productServiceSpyObj = jasmine.createSpyObj('ProductService', ['getProducts']);
    const messageServiceSpyObj = jasmine.createSpyObj('MessageService', ['add']);

    await TestBed.configureTestingModule({
      imports: [
        ProductTableComponent,
        HttpClientTestingModule
      ],
      providers: [
        { provide: ProductService, useValue: productServiceSpyObj },
        { provide: MessageService, useValue: messageServiceSpyObj }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });


  /********************** TEST FOR FUNCTION getSeverityStock ****************/
  it('should return "bg-red-200" when stock is 0', () => {
    const result = component.getSeverityStock(0);
    expect(result).toBe('bg-red-200');
  });

  it('should return "bg-yellow-200" when stock is less than 5 but greater than 0', () => {
    const result = component.getSeverityStock(3);
    expect(result).toBe('bg-yellow-200');
  });

  it('should return an empty string when stock is 5 or more', () => {
    const result = component.getSeverityStock(5);
    expect(result).toBe('');
  });

  it('should return an empty string when stock is more than 5', () => {
    const result = component.getSeverityStock(10);
    expect(result).toBe('');
  });
});
