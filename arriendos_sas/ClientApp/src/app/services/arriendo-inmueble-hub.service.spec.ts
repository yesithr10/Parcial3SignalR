import { TestBed } from '@angular/core/testing';

import { ArriendoInmuebleHubService } from './arriendo-inmueble-hub.service';

describe('ArriendoInmuebleHubService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ArriendoInmuebleHubService = TestBed.get(ArriendoInmuebleHubService);
    expect(service).toBeTruthy();
  });
});
