import { Live } from './../models/live';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class LiveService {

  constructor(private http: HttpClient) { }

  baseUrl = "https://localhost:44314/api/Live";

  public getLive(): Observable<Live[]> {
    return this.http.get<Live[]>(this.baseUrl).pipe(take(1));
  }

  public getLiveByNome(Nome: string): Observable<Live[]> {
    return this.http.get<Live[]>(`${this.baseUrl}/${Nome}/name`).pipe(take(1));
  }

  public getLiveById(Id: number): Observable<Live> {
    return this.http.get<Live>(`${this.baseUrl}/id/${Id}`).pipe(take(1));
  }

  public post(inst: Live): Observable<Live> {
    return this.http.post<Live>(this.baseUrl, inst).pipe(take(1));
  }

  public put(inst: Live): Observable<Live> {
    return this.http.put<Live>(`${this.baseUrl}/${inst.id}`, inst).pipe(take(1));
  }

  public deleteLive(Id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${Id}`).pipe(take(1));
  }

}
