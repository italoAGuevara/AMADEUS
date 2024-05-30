import {Component, ViewChild} from '@angular/core';
import {AvatarModule} from "primeng/avatar";
import {Sidebar, SidebarModule} from "primeng/sidebar";
import {ButtonModule} from "primeng/button";
import {RippleModule} from "primeng/ripple";
import {StyleClassModule} from "primeng/styleclass";
import {RouterLink} from "@angular/router";
import {GlobalSettings} from "../../../../core/globalSettings";

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [
    SidebarModule, ButtonModule, RippleModule, AvatarModule, StyleClassModule, RouterLink
  ],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
  @ViewChild('sidebarRef') sidebarRef!: Sidebar;

  closeCallback(e: any): void {
    this.sidebarRef.close(e);
  }

  sidebarVisible: boolean = false;
  protected readonly GlobalSettings = GlobalSettings;
}
