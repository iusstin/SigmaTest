import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Observable, catchError, throwError } from "rxjs";
import { Candidate } from "./candidate";

@Injectable({
  providedIn: 'root'
})

export class CandidateService {
  private localurl = "https://localhost:7043/api/candidates"
  private url = "https://app-sigmatask-westeu-002-hxgzdzdyayb0e0bd.westeurope-01.azurewebsites.net/api/candidates"

  httpOptions = {
    headers: new HttpHeaders({'Content-Type':'application/json'})
  }

  constructor(private http: HttpClient) {}

  getCandidates(): Observable<Candidate[]> {
    return this.http.get<Candidate[]>(this.url).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = err.error;
    return throwError(() => new Error(errorMessage));
  }
}