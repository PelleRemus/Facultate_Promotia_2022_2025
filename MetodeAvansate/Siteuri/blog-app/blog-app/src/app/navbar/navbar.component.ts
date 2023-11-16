import { Component } from '@angular/core';
import { NgbOffcanvas, OffcanvasDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { GlobalService } from '../services/global.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
	year = 0;

	constructor(private offcanvasService: NgbOffcanvas, public service: GlobalService) {
		this.year = new Date().getFullYear();
	}

	open(content: any) {
		this.offcanvasService.open(content).result.then();
	}

	switchDark() {
		let body = document.getElementsByTagName("body")[0];

		if(!this.service.isDarkMode) {
			body.classList.add('bootstrap-dark');
		} else {
			body.classList.remove('bootstrap-dark')
		}

		this.service.isDarkMode = !this.service.isDarkMode
	}
}
