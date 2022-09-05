import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { GameInfo } from '../model/game-info.model';
import { Game } from '../model/game.model';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private _url: string = environment.apiUrl;

  constructor(private _httpClient: HttpClient) { }

  addGame = (game: Game) => this._httpClient.post<GameInfo[]>(this._url, game);

  getAllGame = () => this._httpClient.get<GameInfo[]>(this._url);

  getGame = (gameId: string) => this._httpClient.get<Game>(this._url + gameId);

  deleteGame = (gameId: string) => this._httpClient.delete<GameInfo>(this._url + gameId);
}
