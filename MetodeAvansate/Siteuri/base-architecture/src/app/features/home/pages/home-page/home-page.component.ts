import { Component, ViewChild } from '@angular/core';
import { ModalComponent } from 'src/app/shared/components/modal/modal.component';
import { ModalConfiguration } from 'src/app/shared/model/modal-configuration';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent {

  modalConfig: ModalConfiguration = {
    modalTitle: "Example modal title",
    dismissButtonLabel: "Cancel",
    closeButtonLabel: "Ok",
    onClose: () => this.delete(),
    onDismiss: () => { console.log('dismissed') },
    closeButtonClass: "danger"
  } as ModalConfiguration;

  @ViewChild('modal') private modalComponent: ModalComponent = {} as ModalComponent;
  
  async openModal() {
    return await this.modalComponent.open()
  }

  delete() {
    // service.delete(id).subscribe(res => {});
  }
}
