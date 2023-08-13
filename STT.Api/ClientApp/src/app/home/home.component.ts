import { GoodService } from './../services/good.service';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Good } from '../models/good.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  public goods$: Observable<Array<Good>>;

  constructor(private goodService: GoodService) { }

  public ngOnInit(): void {
    this.setGoods();
  }

  public searchByAudio(fileName: string): void {
    this.goods$ = this.goodService.getAllByAudio(fileName);
  }

  public setGoods(): void {
    this.goods$ = this.goodService.getAll();
  }
}
