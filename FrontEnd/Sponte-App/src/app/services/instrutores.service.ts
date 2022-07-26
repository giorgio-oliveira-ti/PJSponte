import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Instrutor } from './../models/instrutor';

@Injectable({
  providedIn: 'root'
})
export class InstrutoresService {
    constructor(private http: HttpClient) { }

    baseUrl = "https://localhost:44314/api/Instrutor";

    public getInstrutores(): Observable<Instrutor[]> {
      return this.http.get<Instrutor[]>(this.baseUrl).pipe(take(1));
    }

    public getInstrutoresByNome(Nome: string): Observable<Instrutor[]> {
      return this.http.get<Instrutor[]>(`${this.baseUrl}/${Nome}/name`).pipe(take(1));
    }

    public getInstrutoresById(Id: number): Observable<Instrutor> {
      return this.http.get<Instrutor>(`${this.baseUrl}/id/${Id}`).pipe(take(1));
    }

    public post(inst: Instrutor): Observable<Instrutor> {
      return this.http.post<Instrutor>(this.baseUrl, inst).pipe(take(1));
    }

    public put(inst: Instrutor): Observable<Instrutor> {
      return this.http.put<Instrutor>(`${this.baseUrl}/${inst.id}`, inst).pipe(take(1));
    }

    public deleteInstrutores(Id: number): Observable<any> {
      return this.http.delete(`${this.baseUrl}/${Id}`).pipe(take(1));
    }

}
