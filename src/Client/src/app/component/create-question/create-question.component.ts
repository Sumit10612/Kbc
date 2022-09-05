import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Option } from 'src/app/model/option.model';
import { Question } from 'src/app/model/question.model';
import { QuestionService } from 'src/app/service/question.service';

@Component({
  selector: 'app-create-question',
  templateUrl: './create-question.component.html',
  styleUrls: ['./create-question.component.scss']
})
export class CreateQuestionComponent {

  question$: Observable<Question> = this._questionService.newQuestionSubject$;

  constructor(private _questionService: QuestionService) { }

  onSubmit(question: Question){
    this._questionService.pushQuestion(question);
    this._questionService.addQuestion();
  }

  setOption = (options: Option[], i: number) => options.forEach((element, index) => {
    if (index == i) element.isCorrect = true;
    else element.isCorrect = false;
  });
}
