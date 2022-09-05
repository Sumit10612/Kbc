import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs';
import { filter, map, shareReplay, switchMap } from 'rxjs/operators';
import { Game } from 'src/app/model/game.model';
import { GameService } from 'src/app/service/game.service';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.scss']
})
export class ShowComponent implements OnInit {

  currentQuestionIndex: number = -1;
  showCorrectOption: boolean = false;
  gameStarted: boolean = false;

  lifeLine = [
    { name: 'audience-poll', imgsrc: '', }
  ]

  prizeMoney = [
    { index: 15, amount: '7 Crore', break: false },
    { index: 14, amount: '5 Crore', break: false },
    { index: 13, amount: '3 Crore', break: false },
    { index: 12, amount: '1 Crore', break: true },
    { index: 11, amount: '50 Lakh', break: false },
    { index: 10, amount: '25 Lakh', break: false },
    { index: 9, amount: '1250000', break: true },
    { index: 8, amount: '640000', break: false },
    { index: 7, amount: '320000', break: false },
    { index: 6, amount: '160000', break: false },
    { index: 5, amount: '80000', break: true },
    { index: 4, amount: '40000', break: false },
    { index: 3, amount: '20000', break: false },
    { index: 2, amount: '10000', break: false },
    { index: 1, amount: '5000', break: false },
  ]

  game$: Observable<Game> = this._activatedRoute.queryParamMap.pipe(
    map(params => params.get('id') ?? ''),
    switchMap((id: string) => this._gameService.getGame(id)),
    shareReplay(1)
  );

  constructor(private _activatedRoute: ActivatedRoute, private _gameService: GameService) { }

  ngOnInit(): void {
  }

  start = () => {
    this.currentQuestionIndex = 0;
    this.gameStarted = true;
  }

  next = () => {
    this.showCorrectOption = false;
    this.currentQuestionIndex++;
  }

  showAnswer = () => this.showCorrectOption = true;
}
