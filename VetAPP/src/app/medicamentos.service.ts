import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Medicamento } from './Medicamento';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class MedicamentosService {
  apiUrl = 'http://localhost:5000/Medicamento';

  constructor(private http: HttpClient) { }

  listar(): Observable<Medicamento[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Medicamento[]>(url);
  }

  buscar(medicamentoId: number): Observable<Medicamento> {
    const url = `${this.apiUrl}/buscar/${medicamentoId}`;
    return this.http.get<Medicamento>(url);
  }

  cadastrar(medicamento: Medicamento): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Medicamento>(url, medicamento, httpOptions);
  }

  alterar(medicamento: Medicamento): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Medicamento>(url, medicamento, httpOptions);
  }

  excluir(medicamentoId: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${medicamentoId}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
