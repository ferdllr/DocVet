import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Vacina } from './Vacina';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class VacinasService {
  apiUrl = 'http://localhost:5000/Vacina';

  constructor(private http: HttpClient) { }

  listar(): Observable<Vacina[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Vacina[]>(url);
  }

  buscar(vacinaId: number): Observable<Vacina> {
    const url = `${this.apiUrl}/buscar/${vacinaId}`;
    return this.http.get<Vacina>(url);
  }

  cadastrar(vacina: Vacina): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Vacina>(url, vacina, httpOptions);
  }

  alterar(vacina: Vacina): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Vacina>(url, vacina, httpOptions);
  }

  excluir(vacinaId: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${vacinaId}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
