import { Component, OnInit } from '@angular/core';
import { Player } from '../player';
import { PlayersService } from '../players.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent implements OnInit {

  players: Player[] = [];

  constructor(public playersService: PlayersService) { }

  ngOnInit() {
    this.getPlayerList();
  }

  getPlayerList(): void {
    this.playersService.getPlayers().subscribe({
      next: (response) => {
        this.players = response;
        console.log(response);
      }
    });
  }

  deletePlayer(id: number): void {
    this.playersService.deletePlayer(id).subscribe(res => {
      this.players = this.players.filter(item => item.id !== id);
    });
  }

}
