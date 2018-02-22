export interface ITeam {
  id: number;
  teamId: number;
  name: string;
  lastPosition: number;
  lastPoints: number;
  firstGpTrack: number;
  firstGpYear: number;
  wins: number;
  yearlyBudget: number;
  countryMapId: number;
  locationPointerX: number;
  locationPointerY: number;
  tyreSupplierId: number;
  chassisHandling: number;
  carNumberDriver1: number;
  carNumberDriver2: number;
}
