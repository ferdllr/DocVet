import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tutor } from './Tutor';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class TutoresService {
  apiUrl = 'http://localhost:5000/Tutor';
  constructor(private http: HttpClient) { }
  listar(): Observable<Tutor[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Tutor[]>(url);
  }

  buscar(tutorId: number): Observable<Tutor> {
    const url = `${this.apiUrl}/buscar/${tutorId}`;
    return this.http.get<Tutor>(url);
  }
  cadastrar(tutor: Tutor): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Tutor>(url, tutor, httpOptions);
  }

  alterar(tutor: Tutor): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Tutor>(url, tutor, httpOptions);
  }
  excluir(tutorId: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${tutorId}`;
    return this.http.delete<string>(url, httpOptions);
  }
}