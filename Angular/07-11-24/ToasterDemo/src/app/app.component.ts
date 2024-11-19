import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToasterDemoComponent } from "./toaster-demo/toaster-demo.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ToasterDemoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ToasterDemo';
}
