import { User } from "./user";

export interface Article {
    id: number;
    authorId: number;
    author: User;
    title: string;
    content: string;
}