import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Prontuario } from './Prontuario';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ProntuariosService {
  apiUrl = 'http://localhost:5000/Prontuario';

  constructor(private http: HttpClient) { }

  listar(): Observable<Prontuario[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Prontuario[]>(url);
  }

  buscar(prontuarioId: number): Observable<Prontuario> {
    const url = `${this.apiUrl}/buscar/${prontuarioId}`;
    return this.http.get<Prontuario>(url);
  }

  cadastrar(prontuario: Prontuario): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Prontuario>(url, prontuario, httpOptions);
  }

  alterar(prontuario: Prontuario): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Prontuario>(url, prontuario, httpOptions);
  }

  excluir(prontuarioId: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${prontuarioId}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
