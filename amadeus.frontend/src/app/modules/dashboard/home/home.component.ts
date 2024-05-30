import { Component } from '@angular/core';
import {SidebarComponent} from "../shared/sidebar/sidebar.component";
import {ProductTableComponent} from "../product-table/product-table.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    SidebarComponent,
    ProductTableComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
