import { Component } from '@angular/core';
import { NgbOffcanvas, OffcanvasDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
	isDarkMode = true;

	constructor(private offcanvasService: NgbOffcanvas) {}

	open(content: any) {
		this.offcanvasService.open(content).result.then();
	}

	switchDark() {
		let body = document.getElementsByTagName("body")[0];

		if(!this.isDarkMode) {
			body.classList.add('bootstrap-dark');
		} else {
			body.classList.remove('bootstrap-dark')
		}

		this.isDarkMode = !this.isDarkMode;
	}
}
