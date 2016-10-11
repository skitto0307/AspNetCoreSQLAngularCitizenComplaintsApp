import { CitizenComplaintsClientPage } from './app.po';

describe('citizen-complaints-client App', function() {
  let page: CitizenComplaintsClientPage;

  beforeEach(() => {
    page = new CitizenComplaintsClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
