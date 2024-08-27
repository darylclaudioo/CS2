import { Team } from "./team";

export interface Player {
  id: number,
  playerName: string,
  ingameName: string,
  salary: number,
  isActive: boolean,
  nationality: string,
  teamId: number,
  team?: Team
}
