import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Procedimento } from './Procedimento';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ProcedimentosService {
  apiUrl = 'http://localhost:5000/Procedimento';
  constructor(private http: HttpClient) { }
  listar(): Observable<Procedimento[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Procedimento[]>(url);
  }

  buscar(procedimentoId: number): Observable<Procedimento> {
    const url = `${this.apiUrl}/buscar/${procedimentoId}`;
    return this.http.get<Procedimento>(url);
  }
  cadastrar(procedimento: Procedimento): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Procedimento>(url, procedimento, httpOptions);
  }

  alterar(procedimento: Procedimento): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Procedimento>(url, procedimento, httpOptions);
  }
  excluir(procedimentoId: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${procedimentoId}`;
    return this.http.delete<string>(url, httpOptions);
  }
}