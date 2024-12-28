export interface ResultModel<T> {
    success : boolean;
    data : T;
    errorCode : number;
    errorMessage : string
}