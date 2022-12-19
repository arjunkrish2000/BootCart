import { Component, Input } from '@angular/core';

@Component({
  selector: 'public-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  @Input() view: 'grid' | 'list' = 'grid';
  constructor() {}

  ngOnInit(): void {}
}
