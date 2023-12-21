import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonWithAnimationsComponent } from './components/button-with-animations/button-with-animations.component';
import { ModalComponent } from './components/modal/modal.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [
    ButtonWithAnimationsComponent,
    ModalComponent
  ],
  imports: [
    CommonModule,
    NgbModule
  ],
  exports: [
    ButtonWithAnimationsComponent,
    ModalComponent
  ]
})
export class SharedModule { }
