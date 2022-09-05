import { Question } from "./question.model";

export interface Game {
    id?: string,
    name: string,
    description?: string,
    questions: Question[],
    isPrivate?: boolean,
    dateCreated?: Date
}