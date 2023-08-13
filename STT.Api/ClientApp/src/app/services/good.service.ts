import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Good } from "../models/good.model";

@Injectable({
    providedIn: 'root',
})
export class GoodService {
    private baseUrl: string;

    public constructor(
        private httpClient: HttpClient,
        @Inject('BASE_URL') baseUrl: string,
    ) { 
        this.baseUrl = baseUrl;
    }

    public getAll(): Observable<Array<Good>> {
        return this.httpClient.get<Array<Good>>(`${this.baseUrl}api/goods`);
    }

    public getAllByAudio(fileName: string): Observable<Array<Good>> {
        return this.httpClient.post<Array<Good>>(`${this.baseUrl}api/goods/audio`, { fileName });
    }
}