import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { GameInfo } from 'src/app/model/game-info.model';
import { GameService } from 'src/app/service/game.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {

  games$: Observable<GameInfo[]> = this._gameService.getAllGame();

  constructor(private _gameService: GameService) { }

  deleteGame = (id: string) => this._gameService.deleteGame(id).subscribe();
}
