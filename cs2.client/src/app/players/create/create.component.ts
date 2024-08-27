import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { PlayersService } from "../players.service";
import { TeamsService } from "../teams.service";
import { Team } from '../team';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  teams: Team[] = [];
  createForm;

  constructor(
    public playersService: PlayersService,
    public teamService: TeamsService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.createForm = this.formBuilder.group({
      playerName: ['', Validators.required],
      ingameName: ['', Validators.required],
      teamId: [0, Validators.required],
      nationality: [''],
      salary: [0],
      isActive: [false],
    });
  }

  ngOnInit(): void {
    this.teamService.getTeams().subscribe((data: Team[]) => {
      this.teams = data;
    });
  }

  onSubmit(formData: any) {
    this.playersService.createPlayer(formData.value).subscribe(res => {
      this.router.navigateByUrl('players/list');
    });
  }
}
