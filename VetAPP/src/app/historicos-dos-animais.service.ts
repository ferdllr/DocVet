import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HistoricoDoAnimal } from './HistoricoDoAnimal';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class HistoricosDosAnimaisService {
  apiUrl = 'http://localhost:5000/HistoricoDoAnimal';

  constructor(private http: HttpClient) {}

  listar(): Observable<HistoricoDoAnimal[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<HistoricoDoAnimal[]>(url);
  }

  buscar(historicoDoAnimalId: number): Observable<HistoricoDoAnimal> {
    const url = `${this.apiUrl}/buscar/${historicoDoAnimalId}`;
    return this.http.get<HistoricoDoAnimal>(url);
  }

  cadastrar(historicoDoAnimal: HistoricoDoAnimal): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<HistoricoDoAnimal>(url, historicoDoAnimal, httpOptions);
  }

  alterar(historicoDoAnimal: HistoricoDoAnimal): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<HistoricoDoAnimal>(url, historicoDoAnimal, httpOptions);
  }

  excluir(historicoDoAnimalId: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${historicoDoAnimalId}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
