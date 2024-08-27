import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Player } from "../player";
import { Team } from "../team";
import { PlayersService } from "../players.service";
import { TeamsService } from "../teams.service";


@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  id!: number;
  player!: Player;
  teams: Team[] = [];
  editForm;

  constructor(
    public playersService: PlayersService,
    public TeamsService: TeamsService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.editForm = this.formBuilder.group({
      id: [0],
      playerName: ['', Validators.required],
      ingameName: ['', Validators.required],
      teamId: [0, Validators.required],
      nationality: [''],
      salary: [0],
      isActive: [false],
    });
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['playerId'];

    this.TeamsService.getTeams().subscribe((data: Team[]) => {
      this.teams = data;
    });

    this.playersService.getPlayer(this.id).subscribe((data: Player) => {
      this.player = data;
      this.editForm.patchValue({
        id: data.id,
        playerName: data.playerName,
        ingameName: data.ingameName,
        teamId: data.team ? data.team.id : 0,
        nationality: data.nationality,
        salary: data.salary,
        isActive: data.isActive,
      });
    });
  }

  onSubmit(formData: any) {
    this.playersService.updatePlayer(this.id, formData.value).subscribe(res => {
      this.router.navigateByUrl('players/list');
    });
  }
}
