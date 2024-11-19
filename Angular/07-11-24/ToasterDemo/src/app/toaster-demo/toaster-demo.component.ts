
import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-toaster-demo',
  standalone: true,
  imports: [ ],
  templateUrl: './toaster-demo.component.html',
  styleUrl: './toaster-demo.component.css'
})
export class ToasterDemoComponent {
  constructor(private toastr: ToastrService) { }

    showSuccess() {
        this.toastr.success('Success message', 'Success');
    }

    showError() {
        this.toastr.error('Error message', 'Error');
    }
}
