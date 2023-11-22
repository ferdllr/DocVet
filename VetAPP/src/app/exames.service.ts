import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Exame } from './Exame';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ExamesService {
  apiUrl = 'http://localhost:5000/Exame';

  constructor(private http: HttpClient) { }

  listar(): Observable<Exame[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Exame[]>(url);
  }

  buscar(exameId: number): Observable<Exame> {
    const url = `${this.apiUrl}/buscar/${exameId}`;
    return this.http.get<Exame>(url);
  }

  cadastrar(exame: Exame): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Exame>(url, exame, httpOptions);
  }

  alterar(exame: Exame): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Exame>(url, exame, httpOptions);
  }

  excluir(exameId: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${exameId}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
