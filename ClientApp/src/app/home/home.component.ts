import { Component } from '@angular/core';
import { Candidate } from '../candidate';
import { CandidateService } from '../candidate.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  candidates: Candidate[] = [];

  constructor(private candidatesService: CandidateService) { }

  ngOnInit(): void {
    this.getCandidates();
  }

  getCandidates(): void {
    this.candidatesService.getCandidates().subscribe({
      next: result => {
        console.log("Candidatii sunt: ", result);
        this.candidates = result;
      },
      error: err => {
        console.log(err.message);
      }
    });
  }
}
