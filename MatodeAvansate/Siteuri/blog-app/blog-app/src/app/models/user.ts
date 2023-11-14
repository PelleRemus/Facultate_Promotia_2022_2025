import { Article } from "./article";

export interface User {
    id: number;
    firstName: string;
    lastName: string;
    nickName: string;
    password: string;
    email: string;
    phone: string;
    birthDate: Date;
    articles: Article[];
}