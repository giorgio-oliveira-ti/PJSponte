import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Inscrito } from '@app/models/inscrito';

@Injectable({
  providedIn: 'root'
})
export class InscritosService {

  constructor(private http: HttpClient) { }

  baseUrl = "https://localhost:44314/api/Inscrito";

  public getInscrito(): Observable<Inscrito[]> {
    return this.http.get<Inscrito[]>(this.baseUrl).pipe(take(1));
  }

  public getInscritoByNome(Nome: string): Observable<Inscrito[]> {
    return this.http.get<Inscrito[]>(`${this.baseUrl}/${Nome}/name`).pipe(take(1));
  }

  public getInscritoById(Id: number): Observable<Inscrito> {
    return this.http.get<Inscrito>(`${this.baseUrl}/id/${Id}`).pipe(take(1));
  }

  public post(inst: Inscrito): Observable<Inscrito> {
    return this.http.post<Inscrito>(this.baseUrl, inst).pipe(take(1));
  }

  public put(inst: Inscrito): Observable<Inscrito> {
    return this.http.put<Inscrito>(`${this.baseUrl}/${inst.id}`, inst).pipe(take(1));
  }

  public deleteInscrito(Id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${Id}`).pipe(take(1));
  }


}
