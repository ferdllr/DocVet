import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Alimentacao } from './Alimentacao';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class AlimentacoesService {
  apiUrl = 'http://localhost:5000/Alimentacao';
  constructor(private http: HttpClient) { }
  listar(): Observable<Alimentacao[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Alimentacao[]>(url);
  }

  buscar(alimentacaoId: number): Observable<Alimentacao> {
    const url = `${this.apiUrl}/buscar/${alimentacaoId}`;
    return this.http.get<Alimentacao>(url);
  }
  cadastrar(alimentacao: Alimentacao): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Alimentacao>(url, alimentacao, httpOptions);
  }

  alterar(alimentacao: Alimentacao): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Alimentacao>(url, alimentacao, httpOptions);
  }
  excluir(alimentacaoId: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${alimentacaoId}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
