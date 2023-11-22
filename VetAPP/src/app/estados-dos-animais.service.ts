import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EstadoDoAnimal } from './EstadoDoAnimal';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class EstadosDosAnimaisService {
  apiUrl = 'http://localhost:5000/EstadoDoAnimal';
  constructor(private http: HttpClient) { }
  listar(): Observable<EstadoDoAnimal[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<EstadoDoAnimal[]>(url);
  }

  buscar(estadoDoAnimalId: number): Observable<EstadoDoAnimal> {
    const url = `${this.apiUrl}/buscar/${estadoDoAnimalId}`;
    return this.http.get<EstadoDoAnimal>(url);
  }
  cadastrar(estadoDoAnimal: EstadoDoAnimal): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<EstadoDoAnimal>(url, estadoDoAnimal, httpOptions);
  }

  alterar(estadoDoAnimal: EstadoDoAnimal): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<EstadoDoAnimal>(url, estadoDoAnimal, httpOptions);
  }
  excluir(estadoDoAnimalId: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${estadoDoAnimalId}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
