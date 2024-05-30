import {Component, OnInit} from '@angular/core';
import {TableModule} from "primeng/table";
import {CommonModule} from "@angular/common";
import {ButtonModule} from "primeng/button";
import {AddProductPetition, Product} from "../../../core/entities/Product";
import {ProductService} from "../services/product.service";
import {DialogModule} from "primeng/dialog";
import {RippleModule} from "primeng/ripple";
import {ToastModule} from "primeng/toast";
import {ToolbarModule} from "primeng/toolbar";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {InputTextModule} from "primeng/inputtext";
import {InputTextareaModule} from "primeng/inputtextarea";
import {FileUploadModule} from "primeng/fileupload";
import {DropdownModule} from "primeng/dropdown";
import {TagModule} from "primeng/tag";
import {RatingModule} from "primeng/rating";
import {RadioButtonModule} from "primeng/radiobutton";
import {FormsModule} from "@angular/forms";
import {InputNumberModule} from "primeng/inputnumber";
import {ConfirmationService, MessageService} from "primeng/api";
import {CalendarModule} from "primeng/calendar";
import {SelectButtonModule} from "primeng/selectbutton";
import {CheckboxModule} from "primeng/checkbox";
import {InputSwitchModule} from "primeng/inputswitch";

@Component({
  selector: 'app-product-table',
  standalone: true,
  imports: [TableModule, DialogModule, RippleModule, ButtonModule, ToastModule,
    ToolbarModule, ConfirmDialogModule, InputTextModule, InputTextareaModule, CommonModule,
    FileUploadModule, DropdownModule, TagModule, RadioButtonModule, RatingModule,
    InputTextModule, FormsModule, InputNumberModule, CalendarModule, SelectButtonModule, CheckboxModule, InputSwitchModule],
  providers: [MessageService, ConfirmationService, ProductService],
  templateUrl: './product-table.component.html',
  styleUrl: './product-table.component.css'
})
export class ProductTableComponent implements  OnInit {

  date : Date = new Date();

  productId : string = ''
  productDialog: boolean = false;

  products!: Product[];

  product!: Product;

  selectedProducts!: Product[] | null;

  submitted: boolean = false;

  body : AddProductPetition = { barCode : '', name : '', price : 0, description : '', stockQuantity : 0}

  headerMessage : string = ''

  constructor(private productService: ProductService, private messageService: MessageService, private confirmationService: ConfirmationService) {}

  ngOnInit() {
    this.getProducts();

  }

  openNew() {
    this.product = {barCode : '', id : '', name : '', stockQuantity : 0, tmStmp : '', price : 0, description : ''}
    this.submitted = false;
    this.productDialog = true;

    this.headerMessage = 'Agregar nuevo producto'
  }

  editProduct(product: Product) {
    this.product = { ...product };
    this.productDialog = true;
    this.date = new Date(this.product.tmStmp)
    this.headerMessage = 'Editar producto'
  }

  deleteProduct(product: Product) {
    this.confirmationService.confirm({
      acceptLabel : 'SI',
      message: "Seguro desea eliminar '" + product.name + "'?",
      header: 'Confirmar eliminación',
      acceptButtonStyleClass:"p-button-danger-outlined p-button-text",
      rejectButtonStyleClass:"p-button-text-outlined",
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.productService.deleteProductById(product.id).subscribe({
          next : (data) => {
            this.products = this.products.filter((val) => val.id !== product.id);
            this.product = {barCode : '', id : '', name : '', stockQuantity : 0, tmStmp : '', price : 0, description : ''}
            this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Producto eliminado', life: 3000 });
            this.getProducts();
          },
          error : (error) => {
            console.log(error)
            this.products = this.products.filter((val) => val.id !== product.id);
            this.product = {barCode : '', id : '', name : '', stockQuantity : 0, tmStmp : '', price : 0, description : ''}
            this.messageService.add({ severity: 'warning', summary: 'Error, algo salio mal', detail: 'Producto no eliminado', life: 3000 });
          },
          complete : () => {}
        })

      }
    });
  }

  hideDialog() {
    this.productDialog = false;
    this.submitted = false;
  }

  saveProduct() {

    this.submitted = true;

    if (this.product.name?.trim()) {

      //product exist because has id
      if (this.product.id) {
        this.productService.updateProduct(this.product).subscribe({
          next : (data) => {
            this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Producto Actualizado', life: 3000 });
          },
          error : (error) => {
            console.log(error)
            this.messageService.add({ severity: 'error', summary: 'ERROR', detail: error, life: 5000 });
          },
          complete : () => {
            this.getProducts();
          }
        })


      //if product no exist because does not have id, then create it
      } else {

        if(this.product.barCode == ''){
          this.messageService.add({ severity: 'error', summary: 'ERROR', detail: 'El código de barras es requerido', life: 5000 });
          return;
        }

        this.body = {
          barCode: this.product.barCode,
          stockQuantity: this.product.stockQuantity,
          description: this.product.description,
          price : this.product.price,
          name : this.product.name
        }

        this.productService.saveProduct(this.body).subscribe({
          next : (data) => {
            this.products.push(this.product);
            this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Producto Creado', life: 3000 });
          },
          error : (error) => {
            console.log(error)
            this.messageService.add({ severity: 'error', summary: 'ERROR', detail: error.error.Details, life: 5000 });
          },
          complete : () => {
            this.getProducts();
          }
        })
      }

      this.products = [...this.products];
      this.productDialog = false;
      this.product = {barCode : '', id : '', name : '', stockQuantity : 0, tmStmp : '', price : 0, description : ''}
    }

  }
  pageChange(e : any){
   //console.log(e)
  }

  /***
   * Find by id, the id should be a Guid, for that reason the regex validation was implemented
   */
  findProductById(){
    const guidRegex = /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[1-5][0-9a-fA-F]{3}-[89abAB][0-9a-fA-F]{3}-[0-9a-fA-F]{12}$/;

    if(this.productId.length > 33){
      if(guidRegex.test(this.productId)){
        this.productService.getProductById(this.productId).subscribe({
          next : (data) => {
            this.products = []
            this.products.push(data)
          },
          error : (error) => {
            this.messageService.add({ severity: 'info', summary: 'ERROR', detail: 'producto no encontrado', life: 4000 });
            this.products = []
          },
          complete: () => {}
        })
      }else{
        this.messageService.add({ severity: 'warn', summary: 'ERROR', detail: 'identificador no valido', life: 1000 });
      }

    }else if(this.productId == ''){
      this.getProducts();
    }
  }

  getProducts(){
    this.productService.getProducts().subscribe({
      next : (data) =>{
        this.products = data
      },
      error : (error) => {
        console.log(error)
        this.messageService.add(
          { severity: 'error',
            summary: 'ERROR',
            detail: 'Ha ocurrido un error, por favor contacta al administrador',
            life: 5000
          });
      },
      complete:()=> {}
    });
  }

  getSeverityStock(stock : number) : string{

    if(stock == 0){
      return "bg-red-200"
    }else if(stock < 5){
      return "bg-yellow-200"
    }

    return "";
  }

}
